import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5026", // Ensure this matches your backend server URL
  headers: {
    Authorization: `Bearer ${localStorage.getItem("token")}`
  }
});

export default api;
