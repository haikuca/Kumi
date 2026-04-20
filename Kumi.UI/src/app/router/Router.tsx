import { createBrowserRouter } from "react-router";
import App from "../layout/App";
import Chat from "../../features/chat/Chat";
import Tools from "../../features/tools/Tools";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    children: [
      {
        path: "/",
        element: <Chat/>
      },
      {
        path: "/tools",
        element: <Tools/>
      }
    ]
  }
])
