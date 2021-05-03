import Head from "next/head";
import { signIn, signOut, useSession } from "next-auth/client";
export default function Home() {
  const [session, loading] = useSession();
  return (
    <div className="flex flex-col items-center justify-center min-h-screen py-2">
      <Head>
        <title>Create Next App</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main className="flex flex-col items-center justify-center flex-1 px-20 text-center">
        {!session && (
          <>
            Not signed in <br />
            <button
              className="text-2xl  font-bold p-10"
              onClick={() => signIn()}
            >
              Sign in
            </button>
          </>
        )}
        {session && (
          <>
            Signed in as {session.user.email} <br />
            {console.log(session)}
            <button
              className="text-2xl font-bold p-10"
              onClick={() => signOut()}
            >
              Sign out
            </button>
          </>
        )}
      </main>
    </div>
  );
}
