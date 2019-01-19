#!/usr/bin/env bash
docker-compose -f nginx-proxy/docker-compose.yml down && docker-compose -f mongodb/docker-compose.yml down && docker-compose -f web/docker-compose.yml down
