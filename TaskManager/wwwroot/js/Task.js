$(document).ready(function () {
    $('#addTaskModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var storyId = button.data('story-id'); // Extract info from data-* attributes

        var modal = $(this);
        modal.find('input[name="StoryId"]').val(storyId); // Set the story ID in the form
    });

    $('#createTaskForm').on('submit', function (e) {
        e.preventDefault();
        $('#loadingIndicator').show(); // Show loading indicator

        $.ajax({
            type: 'POST',
            url: '/Task/Create',
            data: $(this).serialize(),
            success: function (response) {
                $('#loadingIndicator').hide();
                $('#addTaskModal').modal('hide');
                location.reload();
            },
            error: function (xhr, status, error) {
                $('#loadingIndicator').hide();
                var errorMessage = xhr.responseText || 'An error occurred while adding the task: ' + error;
                $('#errorMessage').text(errorMessage).show();
            }
        });
    });

