import axios from "axios";

const agent = axios.create({
  baseURL: `/api/v1`,
  withCredentials: true
});

export default agent;
