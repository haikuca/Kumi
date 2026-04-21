import type { Parameter } from "./Parameter";

export type Tool = {
  toolId?: string;
  url: string;
  method: "GET" | "POST";
  name: string;
  description: string;
  parameters: Map<string, Parameter>
}
