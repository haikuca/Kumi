import { createBrowserRouter } from "react-router";
import App from "../layout/App";
import Chat from "../../features/chat/Chat";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children: [
      {
        path: "/",
        element: <Chat/>
      }
    ]
  }
])
