import Modal from "../../../components/Modal";

interface Props {
  handleDeleteTool: () => void;
  closeModal: () => void;
}

export default function DeleteToolModal({ handleDeleteTool, closeModal }: Props) {


  return (
    <Modal title="Confirm delete tool" onSubmit={handleDeleteTool} onCancel={() => closeModal()}>
      <p className="text-white">Are you sure you want to delete this tool?</p>
    </Modal>
  )
}
