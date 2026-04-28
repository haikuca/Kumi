import Modal from "../../../components/Modal";
import Input from "../../../components/Input";
import { useForm } from "react-hook-form";
import type { Tool } from "../../../lib/types/Tool";
import type { Parameter } from "../../../lib/types/Parameter";
import { useState } from "react";

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

  
  
  const [ parameters, setParameters ] = useState<RawParameter[]>([]);
  const { register, handleSubmit } = useForm<Tool>();

  function onSubmit(data: Tool) {
    console.log(data);
  }

  function addParameter() {
    setParameters([...parameters, {} as RawParameter])
  }

  return (
    <Modal title="Create tool" onSubmit={handleSubmit(onSubmit)} onCancel={closeModal}>
      <Input label="URL" register={register} field="url" placeholder="http://locahost:8080" />
      <Input label="Method" register={register} field="method" placeholder="POST" />
      <Input label="Tool name" register={register} field="name" placeholder="example_tool" />
      <Input label="Tool description" register={register} field="description" placeholder="This is an example tool" />
      <p className="mt-3 text-white cursor-pointer">Tool parameters</p>
      <hr className="h-px my-2 bg-neutral-700 border-0"></hr>
      <div className="w-full pl-8">
        { parameters.map((parameter) => (
          <div>
            <Input label="Name" register={register} field="name" placeholder="foo" />
            <Input label="Type" register={register} field="type" placeholder="string"/>
            <Input label="Description" register={register} field="description" placeholder="example description for parameter"/>
          </div>
        )) }
      </div>
      <button onClick={() => addParameter()} className="w-full px-4 py-2 mt-8 rounded-lg bg-neutral-700 text-white cursor-pointer">Add parameter</button>
    </Modal>
  )
}
