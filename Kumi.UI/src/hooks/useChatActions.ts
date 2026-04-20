import { useMutation, useQueryClient } from "@tanstack/react-query";
import type { ChatMessage } from "../lib/types/ChatMessage";
import agent from "../lib/api/Agent";

export function useSendPrompt() {
  const client = useQueryClient();
  return useMutation({
    mutationFn: async (chatMessage: ChatMessage) => {
      const response = await agent.post("/chat", chatMessage)
      return response.data;
    },
    onSuccess: async () => {
      await client.invalidateQueries({
        queryKey: ["chat"]
      })
    }
  })
}
