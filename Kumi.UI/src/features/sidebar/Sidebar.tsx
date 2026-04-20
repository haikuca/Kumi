import SidebarItem from "./SidebarItem";

export default function Sidebar() {
  return (
    <div>
      <aside className="fixed w-64 h-full top-0 z-40 bg-neutral-900">
        <div className="h-full px-3 py-4 overflow-y-auto">
          <ul className="space-y-2 font-medium">
            <SidebarItem name="Tools" to="/tools"/>
            <SidebarItem name="Chat" to="/"/>
          </ul>
        </div>
      </aside>
    </div>
  )
}
