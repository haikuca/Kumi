import { useState } from "react";
import { useTools } from "../../hooks/useToolActions"
import ToolList from "./ToolList";
import NewToolModal from "./modals/NewToolModal";

export default function Tools() {
  
  const [ showModal, setShowModal ] = useState<boolean>(false)
  const { data: tools } = useTools();

  return (
    <>
      { showModal && (<NewToolModal closeModal={() => setShowModal(false)}/>)}
      <div>
        <button onClick={() => setShowModal(!showModal)} className="bg-neutral-700 text-white p-3 rounded-lg cursor-pointer">New tool</button>
        <ToolList tools={tools} />
      </div>
    </>
  )
}
