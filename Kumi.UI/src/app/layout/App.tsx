import { Outlet } from "react-router";
import Sidebar from "../../features/sidebar/Sidebar";

export default function App() {
  return (
    <main className="bg-neutral-800 h-screen w-full">
      <Sidebar/>
      <div className="relative left-64 w-[calc(100%-16rem)]">
        <Outlet/>
      </div>
    </main>
  )
}
