import Modal from "../../../components/Modal";
import Input from "../../../components/Input";
import { useForm } from "react-hook-form";
import type { Tool } from "../../../lib/types/Tool";

interface Props {
  closeModal: () => void;
}

export default function NewToolModal({ closeModal }: Props) {
  
  const { register, handleSubmit } = useForm<Tool>();

  function onSubmit(data: Tool) {
    console.log(data);
  }

  return (
    <Modal title="Create tool" onSubmit={handleSubmit(onSubmit)} onCancel={closeModal}>
      <Input register={register} field="url" placeholder="URL" />
      <Input register={register} field="method" placeholder="method" />
      <Input register={register} field="name" placeholder="name" />
      <Input register={register} field="description" placeholder="description" />
      <p className="text-white cursor-pointer">Add Parameters</p>
    </Modal>
  )
}
