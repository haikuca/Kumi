import type { ChatMessage } from "../../lib/types/ChatMessage";
import Message from "./Message";
import Response from "./Response";

interface Props {
  chatMessages: ChatMessage[],
  pending: boolean
}

export default function ChatMessageBox({ chatMessages, pending }: Props) {
  
  return (
    <div className={"w-full h-1/2 " + (chatMessages.length > 0 ? "" : "hidden")}>
      { chatMessages.map((chatMessage: ChatMessage) => (
        chatMessage.type === "PROMPT" 
          ? (<Message message={chatMessage.content}/>)
          : (<Response response={chatMessage.content}/>)
      )) }
      {pending && (<p>Loading...</p>)}
    </div>
  )
}
