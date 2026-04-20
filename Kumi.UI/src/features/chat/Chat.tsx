import { useEffect, useState } from "react";
import ChatMessageBox from "./ChatMessageBox";
import ChatInput from "./ChatInput";
import { useSendPrompt } from "../../hooks/useChatActions";
import type { ChatMessage } from "../../lib/types/ChatMessage";

export default function Chat() {

  const sendPrompt = useSendPrompt(); 
  const [messages, setMessages] = useState<ChatMessage[]>([])

  useEffect(() => {
    console.log("messages", messages)
  }, [messages])

  async function sendMessage(msg: string) {
    await sendPrompt.mutateAsync({
      type: "PROMPT",
      content: msg
    } as ChatMessage, {
      onSuccess: (chatMessages) => {
        setMessages([...messages, ...chatMessages])
        console.log(messages)
      }
    });

    //setMessages([...messages, msg])
  }

  return (
    <div className="bg-neutral-800 h-screen w-full flex items-center justify-center">
      <div className="w-2/3 h-11/12">
        <div className={"w-full h-full " + (messages.length > 0 ? "" : "flex items-center")}>
          <ChatMessageBox chatMessages={messages} pending={sendPrompt.isPending}/>
          <div className={"w-full h-1/2 flex justify-center " + (messages.length > 0 ? "items-end" : "items-center")}>
            <ChatInput sendMessage={sendMessage}/>
          </div>
        </div>
      </div> 
    </div>
  )
}
