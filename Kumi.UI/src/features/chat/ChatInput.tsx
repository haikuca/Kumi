import { useState } from "react";

interface Props {
  sendMessage: (msg: string) => void;
}

export default function ChatInput({ sendMessage }: Props) {
  
  const [message, setMessage] = useState<string>("")

  function handleSubmit(e: any) {
    e.preventDefault();
    sendMessage(message);
    setMessage("")
  }

  return (
    <form className="w-full" onSubmit={handleSubmit}>
      <div>
        <input className="p-4 rounded-3xl text-white bg-neutral-700 w-full " placeholder="Ask Kumi" value={message} onChange={(e) => setMessage(e.target.value)} />
      </div>
    </form>
  )
}
