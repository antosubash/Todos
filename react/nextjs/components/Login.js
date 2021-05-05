import React from "react";
import { signIn, signOut, useSession } from "next-auth/client";
function Login() {
  const [session, loading] = useSession();
  return (
    <>
      {!session && (
        <>
          Not signed in <br />
          <button onClick={() => signIn("identity-server4")}>Sign in</button>
        </>
      )}
      {session && (
        <>
          Signed in as {session.user.email} <br />
          {console.log(session.accessToken)}
          <button onClick={() => signOut()}>Sign out</button>
        </>
      )}
    </>
  );
}

export default Login;
