document.addEventListener("DOMContentLoaded", function () {
    const forms = document.querySelectorAll(".ajax-add-to-cart");

    forms.forEach((form) => {
        form.addEventListener("submit", function (event) {
            event.preventDefault();

            const formData = new FormData(form);
            const csrfToken = form.querySelector("input[name=csrfmiddlewaretoken]").value;
            const url = form.getAttribute("action");

            fetch(url, {
                method: "POST",
                body: formData,
                headers: {
                    "X-CSRFToken": csrfToken,
                },
            })
                .then((response) => response.json())
                .then((data) => {
                    if (data.message) {
                        alert(data.message); // Уведомление об успешном добавлении
                    } else if (data.error) {
                        alert(data.error); // Обработка ошибки
                    }
                })
                .catch((error) => {
                    console.error("Ошибка:", error);
                });
        });
    });
});
