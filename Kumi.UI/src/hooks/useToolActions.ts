import { useQuery } from "@tanstack/react-query";
import agent from "../lib/api/Agent";
import type { Tool } from "../lib/types/Tool";

export function useTools() {
  return useQuery({
    queryKey: ['tools'],
    queryFn: async () => {
      const response = await agent.get<Tool[]>("/tools")
      return response.data;
    }
  })
}
