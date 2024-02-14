## Requirements
1.With Docker
[Get docker](https://docs.docker.com/get-docker/)

## How to use
### Spin up web site locally. Initial run takes time to download .NET Core SDK and MS SQL Server images.
`docker-compose up -d --build`

browse at http://localhost:5000/

### To stop and clean up docker resources
`docker-compose down`
2.Locally with NpgSql
	1.install npgsql locally
	2.Delete line 11 in Program.cs and remove comments from line 13
    3.Update connectionString in Appsettings
