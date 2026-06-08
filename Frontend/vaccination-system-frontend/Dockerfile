# Build
FROM node:24-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm ci

COPY . .

RUN npm run build

# Prepare execution
FROM nginx:alpine AS execute

COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist/*/browser /usr/share/nginx/html

EXPOSE 80

# Execute
CMD ["nginx", "-g", "daemon off;"]