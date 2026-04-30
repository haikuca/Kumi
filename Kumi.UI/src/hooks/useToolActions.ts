import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
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

export function useCreateTool() {
  const client = useQueryClient();
  return useMutation({
    mutationFn: async (tool: Tool) => {
      const response = await agent.post("/tools", tool)
      return response.data;
    },
    onSuccess: async () => {
      await client.invalidateQueries({
        queryKey: ['tools']
      })
    }
  })
}
