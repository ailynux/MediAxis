import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { QueryClient, QueryClientProvider } from "react-query";
import { ThemeProvider } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";
import theme from "./theme";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import Dashboard from "./pages/Dashboard";
import HealthRecords from "./pages/HealthRecords";
import Patients from "./pages/Patients";

// Create a client
const queryClient = new QueryClient();

const App = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Router>
          <Header />
          <Sidebar />
          <main style={{ marginLeft: 240, padding: "1rem" }}>
            <Routes>
              <Route path="/" element={<Dashboard />} />
              <Route path="/healthrecords" element={<HealthRecords />} />
              <Route path="/patients" element={<Patients />} />
              {/* Add other routes here */}
            </Routes>
          </main>
        </Router>
      </ThemeProvider>
    </QueryClientProvider>
  );
};

export default App;
