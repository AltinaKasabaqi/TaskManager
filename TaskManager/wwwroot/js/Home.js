    $(document).ready(function() {
        $('#addStoryForm').on('submit', function (e) {
            e.preventDefault();
            $.ajax({
                type: 'POST',
                url: '/UserStory/Create',
                data: $(this).serialize(),
                success: function (response) {
                    $('#addStoryModal').modal('hide');
                    location.reload(); 
                },
                error: function (xhr, status, error) {
                    alert('An error occurred while adding the story: ' + error);
                }
            });
        })
    });

