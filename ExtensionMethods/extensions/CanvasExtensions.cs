using UnityEngine;

namespace Extensions
{
    public static class CanvasExtensions
    {
        public static Vector2 WorldToCanvas(this Canvas canvas,
                                            Vector3 worldPosition,
                                            Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }

            //pos between 0-1
            var viewport_position = camera.WorldToViewportPoint(worldPosition);

            var canvas_rect = canvas.pixelRect;
            
            //TODO: Use GUIUtility instead
            //Need to adjust due to canvas rect center is origin (0,0) whereas viewport bottom left
            return new Vector2((viewport_position.x * canvas_rect.width) - (canvas_rect.width * 0.5f),
                               (viewport_position.y * canvas_rect.height) - (canvas_rect.height * 0.5f));

        }

        public static Vector3 CanvasToWorld(this Canvas canvas,
                                            Vector3 canvasPosition,
                                            Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }

            Vector3 screen_position = Vector3.zero;
            screen_position.x = (canvasPosition.x / canvas.pixelRect.width) * Screen.width;
            screen_position.y = (canvasPosition.y / canvas.pixelRect.height) * Screen.height;
            //The z position is in world units from the camera, should be > 0
            screen_position.z = canvasPosition.z;

            Vector3 worldPoint = camera.ScreenToWorldPoint(screen_position);
            
            return worldPoint;
        }

        public static Vector3 ScreenToCanvas(this Canvas canvas, Vector3 screenPosition, Camera camera = null)
        {
            if (camera == null)
            {
                camera = Camera.main;
            }

            //TODO: Use GUIUtility instead
            //Convert to canvas coords
            float x = screenPosition.x / Screen.width * canvas.pixelRect.width;
            float y = screenPosition.y / Screen.height * canvas.pixelRect.height;

            return new Vector3(x, y, screenPosition.z);
        }

        //TODO: CanvasToScreen
    }
}
