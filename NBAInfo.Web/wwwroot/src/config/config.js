//Define your server based on the NODE_ENV environment variable
export const server = process.env.NODE_ENV === 'production' ? '/' : 'https://localhost:45455/api/values';