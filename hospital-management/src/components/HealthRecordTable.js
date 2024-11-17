import React, { useState } from "react";
import { useQuery, useMutation, useQueryClient } from "react-query";
import api from "../api";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Paper,
  Typography,
  IconButton,
  TextField,
  Button
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Cancel";

const fetchHealthRecords = async () => {
  const response = await api.get("/api/healthrecords");
  return response.data;
};

const updateHealthRecord = async (record) => {
  await api.put(`/api/healthrecords/${record.id}`, record);
};

const HealthRecordTable = () => {
  const queryClient = useQueryClient();
  const { data, error, isLoading } = useQuery(
    "healthRecords",
    fetchHealthRecords
  );
  const mutation = useMutation(updateHealthRecord, {
    onSuccess: () => {
      queryClient.invalidateQueries("healthRecords");
    }
  });

  const [editId, setEditId] = useState(null);
  const [editData, setEditData] = useState({});

  const handleEdit = (record) => {
    setEditId(record.id);
    setEditData(record);
  };

  const handleSave = () => {
    mutation.mutate(editData);
    setEditId(null);
  };

  const handleCancel = () => {
    setEditId(null);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditData((prevData) => ({
      ...prevData,
      [name]: value
    }));
  };

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
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((record) => (
            <TableRow key={record.id}>
              <TableCell>{record.id}</TableCell>
              <TableCell>
                {editId === record.id ? (
                  <TextField
                    name="patientId"
                    value={editData.patientId}
                    onChange={handleChange}
                  />
                ) : (
                  record.patientId
                )}
              </TableCell>
              <TableCell>
                {editId === record.id ? (
                  <TextField
                    name="diagnosis"
                    value={editData.diagnosis}
                    onChange={handleChange}
                  />
                ) : (
                  record.diagnosis
                )}
              </TableCell>
              <TableCell>
                {editId === record.id ? (
                  <TextField
                    name="treatment"
                    value={editData.treatment}
                    onChange={handleChange}
                  />
                ) : (
                  record.treatment
                )}
              </TableCell>
              <TableCell>
                {editId === record.id ? (
                  <TextField
                    name="date"
                    value={editData.date}
                    onChange={handleChange}
                  />
                ) : (
                  record.date
                )}
              </TableCell>
              <TableCell>
                {editId === record.id ? (
                  <>
                    <IconButton onClick={handleSave}>
                      <SaveIcon />
                    </IconButton>
                    <IconButton onClick={handleCancel}>
                      <CancelIcon />
                    </IconButton>
                  </>
                ) : (
                  <IconButton onClick={() => handleEdit(record)}>
                    <EditIcon />
                  </IconButton>
                )}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
  );
};

export default HealthRecordTable;
