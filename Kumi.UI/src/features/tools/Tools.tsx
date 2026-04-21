import { useTools } from "../../hooks/useToolActions"
import ToolList from "./ToolList";

export default function Tools() {
  
  const { data: tools } = useTools();

  return (
    <ToolList tools={tools} />
  )
}
