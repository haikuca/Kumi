import { Link } from "react-router"

interface Props {
  name: string,
  to: string
}

export default function SidebarItem({ name, to }: Props) {
  return (
    <Link to={ to }>
      <li className="flex w-full text-neutral-400 items-center p-2 rounded-lg cursor-pointer hover:bg-neutral-800 hover:text-white">
        { name }
      </li>
    </Link>
  )
}
