interface Props {
  message: string;
}

export default function Message({ message }: Props) {
  return (
    <div className="p-4 flex justify-end">
      <p className="p-4 rounded-3xl text-white bg-neutral-700">{ message }</p>
    </div>
  )
} 
