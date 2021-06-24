import Link from "next/link";
import Layout from "../components/Layout";
import Container from "@material-ui/core/Container";
import Typography from "@material-ui/core/Typography";
import Box from "@material-ui/core/Box";
import Button from "@material-ui/core/Button";
const AboutPage = () => (
  <Layout title="About | Next.js + TypeScript Example">
    <Container maxWidth="sm">
      <Box>
        <Typography variant="h4" component="h1" gutterBottom>
          Next.js v5-alpha with TypeScript example
        </Typography>
        <Link href="/">Go to the main page</Link>
      </Box>
    </Container>
  </Layout>
);

export default AboutPage;
