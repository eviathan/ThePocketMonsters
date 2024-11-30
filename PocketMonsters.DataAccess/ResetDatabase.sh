#!/bin/bash

rm ../database.db
rm ../database.db-wal
rm ../database.db-shm
rm -rf Migrations/

dotnet ef migrations add Init
dotnet ef database update