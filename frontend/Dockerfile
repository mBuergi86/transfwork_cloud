# Stage 1: Build
FROM node:lts-alpine as build
LABEL Developers="Markus & Martin"
WORKDIR /app
COPY ./package*.json ./
RUN npm ci
COPY . .
RUN chmod -R 777 .
RUN npm run build

# Stage 2: Production
FROM node:lts-alpine as production
COPY --from=build /app/build .
COPY --from=build /app/package.json .
COPY --from=build /app/package-lock.json .
RUN npm ci --omit dev
EXPOSE 3000
CMD ["node", "."]