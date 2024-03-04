function addToCartEvent(event) {
	event.preventDefault();
	let target = event.target;
	let productId = target.getAttribute("data-product-id");
	console.log(productId);
	addToCart(productId);
}

function addToCart(productId) {

	$.ajax({
		url: '/CartItem/AddToCart',
		method: 'POST',
		data: { productId: productId },
		success: function () {
			console.log(`Product ID added: ${productId}`);
			showToast("Item added to Cart successfully!")
		}
	});
}

function showToast(message, delay = 3000) {
	// Create a new toast element
	var toast = $('<div class="toast" role="alert" aria-live="assertive" aria-atomic="true" data-delay="' + delay + '">')
		.addClass('bg-primary text-white')
		.append($('<div class="toast-body">').text(message));

	// Add the toast to the container
	$('#toastContainer').append(toast);

	// Show the toast
	toast.toast('show');

	// Remove the toast after it's hidden
	toast.on('hidden.bs.toast', function () {
		$(this).remove();
	});
}