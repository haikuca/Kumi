import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'

const env = loadEnv(process.env.NODE_ENV as string, process.cwd(), 'VITE_');

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    tailwindcss()
  ],
  server: {
    proxy: {
      '/api/v1': {
        target: "http://localhost:5062",
        changeOrigin: true
      } 
    }
  }
})
