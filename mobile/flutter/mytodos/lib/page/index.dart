import 'package:flutter/material.dart';
import 'package:flutter_appauth/flutter_appauth.dart';
import 'package:openid_client/openid_client.dart';
import 'package:openid_client/openid_client_io.dart';
import 'package:url_launcher/url_launcher.dart';
import 'dart:async';

class HomePage extends StatefulWidget {
  HomePage({Key? key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final FlutterAppAuth _appAuth = FlutterAppAuth();
  // For a list of client IDs, go to httpss://demo.identityserver.io
  final String _clientId = 'Todos_Flutter_2';
  final String _redirectUrl = 'com.todos.native://callback';
  static const String _issuer = 'https://8c80c4d04958.ngrok.io';
  final String _discoveryUrl = _issuer + '/.well-known/openid-configuration';
  final List<String> _scopes = <String>[
    'openid',
    'profile',
    'email',
    'offline_access',
    'Todos'
  ];
  String logoutUrl = "";
  final AuthorizationServiceConfiguration _serviceConfiguration =
      const AuthorizationServiceConfiguration(
          _issuer + '/connect/authorize', _issuer + '/connect/token');

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Home"),
      ),
      body: Container(
        child: Center(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              ElevatedButton(
                child: Text("Login"),
                onPressed: () async {
                  //await signInWithAutoCodeExchange();
                  var info =
                      authenticate(Uri.parse(_issuer), _clientId, _scopes);
                  print(info);
                },
              ),
              ElevatedButton(
                child: Text("Logout"),
                onPressed: () async {
                  logout();
                },
              ),
            ],
          ),
        ),
      ),
    );
  }

  Future<void> signInWithAutoCodeExchange(
      {bool preferEphemeralSession = false}) async {
    try {
      // show that we can also explicitly specify the endpoints rather than getting from the details from the discovery document
      final AuthorizationTokenResponse? result =
          await _appAuth.authorizeAndExchangeCode(
        AuthorizationTokenRequest(_clientId, _redirectUrl,
            serviceConfiguration: _serviceConfiguration,
            scopes: _scopes,
            preferEphemeralSession: preferEphemeralSession,
            promptValues: ["login"]),
      );
      print(result?.accessToken);
    } catch (e) {
      print(e);
    }
  }

  authenticate(Uri uri, String clientId, List<String> scopes) async {
    // create the client
    var issuer = await Issuer.discover(uri);
    var client = new Client(issuer, clientId);

    // create a function to open a browser with an url
    urlLauncher(String url) async {
      if (await canLaunch(url)) {
        await launch(url, forceWebView: true);
      } else {
        throw 'Could not launch $url';
      }
    }

    // create an authenticator
    var authenticator = new Authenticator(
      client,
      scopes: scopes,
      urlLancher: urlLauncher,
      port: 3000,
    );

    // starts the authentication
    var c = await authenticator.authorize();
    // close the webview when finished
    closeWebView();

    var res = await c.getTokenResponse();
    setState(() {
      logoutUrl = c.generateLogoutUrl().toString();
    });
    print("code");
    print(res.accessToken);
    print(logoutUrl);
    // return the user info
    return await c.getUserInfo();
  }

  Future<void> logout() async {
    if (await canLaunch(logoutUrl)) {
      await launch(logoutUrl, forceWebView: true);
    } else {
      throw 'Could not launch $logoutUrl';
    }
    await Future.delayed(Duration(seconds: 2));
    closeWebView();
  }
}
