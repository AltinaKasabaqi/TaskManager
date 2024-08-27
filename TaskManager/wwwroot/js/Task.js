<script>
    $(document).ready(function () {
        $('#createTaskForm').on('submit', function (event) {
            event.preventDefault(); // Prevent the default form submission

            var form = $(this);
            var url = form.attr('action'); // Get the action URL
            var formData = form.serialize(); // Serialize form data

            $.ajax({
                type: 'POST',
                url: url,
                data: formData,
                success: function (response) {
                    $('#formResponse').html('<div class="alert alert-success">Task created successfully!</div>');
                    // Optionally, you can clear the form or perform other actions
                    form[0].reset();
                },
                error: function (xhr, status, error) {
                    $('#formResponse').html('<div class="alert alert-danger">An error occurred: ' + xhr.responseText + '</div>');
                }
            });
        });
    });
</script>
