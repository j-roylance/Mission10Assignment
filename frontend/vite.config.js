import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  server: {
    // Proxy /api requests to the ASP.NET backend so the React app can call the API without CORS issues
    proxy: {
      '/api': 'http://localhost:5150'
    }
  }
})
