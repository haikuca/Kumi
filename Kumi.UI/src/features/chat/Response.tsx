interface Props {
  response: string;
}

export default function Response({ response }: Props) {
  return (
    <div className="p-4 flex justify-start">
      <p className="text-white">{ response }</p>
    </div>
  )
}
