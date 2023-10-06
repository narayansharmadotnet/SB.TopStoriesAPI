# Santander - Developer Coding Test

## Overview
Retrieve the details of the first N "best stories" from the Hacker News API.

The Hacker News API is document https://github.com/HackerNews/API

## Requirements
- DotNet 7.0
- Visual Studio 2022

## How to run
- Open the solution in Visual Studio 2022
- Set the `SB.TopStoriesAPI` project as the startup project
- Set IISExpress
- Run the project
- Open a browser and navigate to `https://localhost:44300/swagger`
- Click on the `GET /api/v1/HackerNewsTopStories` endpoint
- Click on the `Try it out` button
- Enter the number of stories you want to retrieve
- Select disableCache to false
- Click on the `Execute` button
- The response will be displayed in the `Response body` section
- The response will be a JSON array of story objects

## Assumptions
- Using local memory cache but this can be replaced to implement redis cache
- Manual mapping of dto's from hackers api response to api response, but this can be replaced with Mapper nuget package


