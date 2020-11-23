#!/bin/bash
set -e
bash /app/wait-for-it.sh db:5432 --strict --timeout=300 -- dotnet DotnetWebAPI.dll