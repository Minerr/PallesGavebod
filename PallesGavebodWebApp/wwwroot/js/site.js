// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const API_URL = "http://localhost:58175/api/Gifts";

function SendPostRequest(dataToPost)
{

	let request = new XMLHttpRequest();
	request.open("POST", API_URL, true);
	request.setRequestHeader("Content-Type", "application/json");
	request.send(JSON.stringify(dataToPost));	// Convert js object to JSON

	// Use Fetch API (https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API)
	/*fetch(API_URL, {
		method: "POST",
		body: JSON.stringify(gift), // Convert js object to JSON
		headers: {
			"Content-Type": "application/json"
		}
	}).then(function (response) { // After the call has been send and a response has been returned, then use that response in an anonymous function.
		let data = response.json(); //extract JSON from the http response
		console.log(data);
	});*/
}


function ShowGiftInformation(gift, parentNode)
{
	// Create the card for the gift.
	// A bootstrap card needs a container(card class),
	// then a container for header and body.
	let card = document.createElement("div");
	card.setAttribute("class", "card mr-3");

	let cardHeader = document.createElement("div");
	cardHeader.setAttribute("class", "card-header d-flex");

	let cardBody = document.createElement("div");
	cardBody.setAttribute("class", "card-body");

	let cardFooter = document.createElement("div");
	cardFooter.setAttribute("class", "card-footer");

	// Title to display in the header
	let cardTitle = document.createElement("h5");
	cardTitle.setAttribute("class", "card-title");
	cardTitle.innerHTML = "#" + gift.giftNumber + " " + gift.title;

	// Description to display in the body
	let cardDescription = document.createElement("p");
	cardDescription.setAttribute("class", "card-text");
	cardDescription.innerHTML = gift.description;

	// Date to display in the footer
	let cardDate = document.createElement("p");
	cardDate.setAttribute("class", "card-text text-secondary");
	cardDate.innerHTML = "Added on: " + gift.creationDate;


	// Girl or boy tags
	let cardBoyTag = document.createElement("span");
	cardBoyTag.setAttribute("class", "badge badge-primary");
	cardBoyTag.innerHTML = "For boys";

	let cardGirlTag = document.createElement("span");
	cardGirlTag.setAttribute("class", "badge badge-danger");
	cardGirlTag.innerHTML = "For girls";


	// Append the variables to the card header, body or footer
	cardHeader.appendChild(cardTitle);
	cardBody.appendChild(cardDescription);
	cardFooter.appendChild(cardDate);

	// If the gift is for boys or girls, append the tags to the footer.
	if (gift.boyGift) {
		cardFooter.appendChild(cardBoyTag);
	}
	if (gift.girlGift) {
		cardFooter.appendChild(cardGirlTag);
	}

	// Append the header, body or footer to the card container
	card.appendChild(cardHeader);
	card.appendChild(cardBody);
	card.appendChild(cardFooter);

	parentNode.appendChild(card); // Append the card to the specified parentNode parameter
}
