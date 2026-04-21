import type { Tool } from "../../lib/types/Tool"

interface Props {
  tools?: Tool[]
}

export default function ToolList({ tools }: Props) {
  
  console.log(tools)

  return (
    <div className="overflow-x-auto text-white">
      <table className="w-full text-sm text-left text-body">
        <thead>
          <tr>
            <th scope="col" className="px-6 py-3 font-medium">
              Name
            </th>
            <th scope="col" className="px-6 py-3 font-medium">
              Description
            </th>
          </tr>
        </thead>
        <tbody>
          { tools?.map((tool: Tool) => (
            <tr>
              <td className="px-6 py-4 whitespace-nowrap">
                { tool.name }
              </td>
              <td className="px-6 py-4 whitespace-nowrap">
                { tool.description }
              </td>
            </tr>
          )) }
        </tbody>
      </table>
    </div>
  )
}
