# Nginx Reverse Proxy and Load Balancing Demonstration

This repository contains a containerized environment demonstrating advanced Nginx traffic management. It routes traffic to two different backend stacks: .NET 8 and Java 21 (Spring Boot).

## Technical Features

### 1. Traffic Routing Logic

The Nginx configuration implements three concurrent routing methods:
- Header-based: Uses a map directive on the X-App-Type header to choose the upstream.
- Path-based: location blocks for /dotnet/ and /java/ using rewrite to strip prefixes before passing to backends.
- Virtual Hosts: Separate server blocks for dotnet.localhost and java.localhost.

### 2. Load Balancing

Upstream groups are defined for both application stacks, distributing traffic across multiple container instances (dotnet-1, dotnet-2 and java-1, java-2).

### 3. Rate Limiting

A shared memory zone (req_limit) is defined to restrict clients to 20 requests per second, protecting the backend services from burst traffic.

## Project Structure
- `nginx/nginx.conf`: Main configuration file for routing, upstreams, and rate limiting.
- `dotnet/`: Source and Dockerfile for the .NET 8 "Mirror" API.
- `java/`: Source and Dockerfile for the Spring Boot "Mirror" API.
- `demonstration.sh`: A shell script to verify load balancing and rate limiting behavior via curl.

## Deployment

### 1. Build and Start:
```bash
docker compose up -d --build
```

### 2. Verify Routing:
- Header: `curl -H "X-App-Type: java" http://localhost`
- Path: `curl http://localhost/dotnet/`
- Host: `curl -H "Host: java.localhost" http://localhost`
