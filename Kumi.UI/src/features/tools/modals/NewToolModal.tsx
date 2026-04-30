import Modal from "../../../components/Modal";
import Input from "../../../components/Input";
import { useForm } from "react-hook-form";
import type { Tool } from "../../../lib/types/Tool";
import { useState } from "react";
import type { Parameter } from "../../../lib/types/Parameter";
import { useCreateTool } from "../../../hooks/useToolActions";

interface Props {
  closeModal: () => void;
}

type RawParameter = {
  name: string;
  type: string;
  description: string;
  required: boolean;
}

export default function NewToolModal({ closeModal }: Props) {

  const createTool = useCreateTool(); 
  const [ rawParameters, setRawParameters ] = useState<RawParameter[]>([]);
  const { register, handleSubmit } = useForm<Tool>();

  async function onSubmit(data: Tool) {
    data.parameters = mapRawParameters();
    await createTool.mutateAsync(data, {
      onSuccess: () => closeModal()
    })
  }

  function updateParameterValue(parameter, value, e) {
    parameter[value] = e.target.value;
  }

  function mapRawParameters(): Map<string, Parameter> {
    const parameters = new Map<string, Parameter>();

    rawParameters.map((parameter) => {
      parameters.set(parameter.name, {
        type: parameter.type,
        description: parameter.description,
        required: true
      } as Parameter)
    })

    return parameters;
  }

  function renderParameterList() {
    return (
      <div className={"w-full pl-4 pr-3 " + (rawParameters.length > 0 ? "h-38 overflow-y-scroll" : "")}>
        <p className={"text-neutral-500 " + (rawParameters.length > 0 ? "hidden" : "")}>No parameters</p>
        { rawParameters.length > 0 && (
          rawParameters.map((parameter) => (
            <div className="mb-2"> 
              <input onChange={(e) => updateParameterValue(parameter, "name", e)} placeholder="name" className="mb-2 mt-1 py-2 px-2 rounded-lg w-full bg-neutral-700 text-white"/>
              <input onChange={(e) => updateParameterValue(parameter, "type", e)} placeholder="type" className="mb-2 mt-1 py-2 px-2 rounded-lg w-full bg-neutral-700 text-white"/>
              <input onChange={(e) => updateParameterValue(parameter, "description", e)} placeholder="description" className="mb-2 mt-1 py-2 px-2 rounded-lg w-full bg-neutral-700 text-white"/>
            </div>
          ))
        ) }
      </div>
    )
  }

  return (
    <Modal title="Create tool" onSubmit={handleSubmit(onSubmit)} onCancel={closeModal}>
      <Input label="URL" register={register} field="url" placeholder="http://locahost:8080" />
      <Input label="Method" register={register} field="method" placeholder="POST" />
      <Input label="Tool name" register={register} field="name" placeholder="example_tool" />
      <Input label="Tool description" register={register} field="description" placeholder="This is an example tool" />
      <p className="mt-3 text-white cursor-pointer">Tool Parameters</p>
      <hr className="h-px my-2 bg-neutral-700 border-0"></hr>
      { renderParameterList() }
      <button onClick={() => setRawParameters([...rawParameters, {} as RawParameter])} className="w-full px-4 py-2 mt-8 rounded-lg bg-neutral-700 text-white cursor-pointer">Add parameter</button>
    </Modal>
  )
}
