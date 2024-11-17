import { createTheme } from "@mui/material/styles";

const theme = createTheme({
  palette: {
    primary: {
      main: "#1976d2"
    },
    secondary: {
      main: "#dc004e"
    }
  },
  typography: {
    h1: {
      fontSize: "2rem",
      fontWeight: 600
    },
    h2: {
      fontSize: "1.5rem",
      fontWeight: 500
    }
  }
});

export default theme;
