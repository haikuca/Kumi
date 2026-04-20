export type ChatMessage = {
  type: "PROMPT" | "RESPONSE";
  content: string
};
