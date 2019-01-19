#!/usr/bin/env bash
docker-compose -f nginx-proxy/docker-compose.yml up -d && docker-compose -f mongodb/docker-compose.yml up -d && docker-compose -f web/docker-compose.yml up -d