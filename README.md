# Drops
## !LoginPage Vector Graphics failing to Render on android!

## Description

RealDrops is an outdoor Sales Lead management application that allows users to represent potential leads and other entities with a pin(referred to as a drop) using their devices default maps API. Drops are persisted in collections that are members of area objects that have a pair of coordinates to center the map view upon rendering.
Areas also have a collection of 'Subscribers' these are users  who are allowed to access the area and manage it's drops, the subscribers include the owner(the creator of the area) and all the users he has shared this area with. Data is persisted by an Azure Cosmos DB backend, tandem local persistence is still in the works so the application currently requires a network connection.

## File Tree

Drops

	Drops

		Helpers : Contains api key constants, I also want to move this content to static to consolidate ../ members

		Models : Object Models

		Services : Contains logic for interacting with Cosmos DB, I think I'm going to move this Dirs content to Static

		Static : MetaData for Object manipulation and DB interaction

		ViewModels : Value conversion

		Views : ContentPages w/ XAML

		Resources : Contains the Resource files for adaptive styling 

	Drops.Android

		...

	Drops.iOS

		...

	Drops.UWP (not setup yet)
	
		...

## Compatible Environments

- iOS

- Android

- Coming Soon: UWP

## In the Works

- adaptive UI styling for desktop and tablet idoms upon launch

- uwp support

- Drop Editing

- Area Editing

- Custom Rendering for map pins and their popup windows

- Third Party signin

- Account Recovery

- Technical support

- Dynamic User Prompts

![Image of Yaktocat](https://octodex.github.com/images/yaktocat.png)
