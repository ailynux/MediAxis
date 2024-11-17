import React from "react";
import { useQuery } from "react-query";
import api from "../api";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Paper,
  Typography
} from "@mui/material";

const fetchHealthRecords = async () => {
  const response = await api.get("/api/healthrecords");
  return response.data;
};

const HealthRecords = () => {
  const { data, error, isLoading } = useQuery(
    "healthRecords",
    fetchHealthRecords
  );

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>Error loading health records</div>;

  return (
    <Paper>
      <Typography variant="h4" component="h2" gutterBottom>
        Health Records
      </Typography>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>ID</TableCell>
            <TableCell>Patient ID</TableCell>
            <TableCell>Diagnosis</TableCell>
            <TableCell>Treatment</TableCell>
            <TableCell>Date</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((record) => (
            <TableRow key={record.id}>
              <TableCell>{record.id}</TableCell>
              <TableCell>{record.patientId}</TableCell>
              <TableCell>{record.diagnosis}</TableCell>
              <TableCell>{record.treatment}</TableCell>
              <TableCell>{record.date}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
  );
};

export default HealthRecords;
