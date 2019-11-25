using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    #region Variables
    public KeyCode DragNDropOpen = KeyCode.Tab;
    [Header("Inventory")]
    public bool showInv;
    public List<Item> inv = new List<Item>();
    public int slotX, slotY;
    public Rect inventorySize;
    [Header("Dragging")]
    public bool isDragging;
    public int draggedFrom;
    public Item draggedItem;
    public GameObject droppedItem;
    [Header("ToolTip")]
    public int toolTipItem;
    public bool showToolTip;
    public Rect toolTipRect;
    [Header("References & Locations")]
    public Vector2 scr;
    #endregion

    #region Clamp to Screen
    // Limit the window dragging space
    private Rect ClampToScreen(Rect r)
    {
        r.x = Mathf.Clamp(r.x, 0, Screen.width - r.width);
        r.y = Mathf.Clamp(r.y, 0, Screen.height - r.height);

        return r;
    }
    #endregion
    #region Add Item
    private void AddItem(int itemID)
    {
        for (int i = 0; i < inv.Count; i++)
        {
            // If there is nothing create items in the Inventory
            if (inv[i].NAME == null)
            {
                inv[i] = ItemData.CreateItem(itemID);
                Debug.Log("Add Item: " + inv[i].NAME);
                return;
            }
        }
    }
    #endregion
    #region Drop Item
    private void DropItem()
    {
        // If the Item is Dragged out, spawn the mesh randomly, and give it gravity
        droppedItem = draggedItem.ITEMMESH;
        droppedItem = Instantiate(droppedItem, new Vector3(Random.Range(1f, -4f), Random.Range(0f, 2f), Random.Range(1f, 6f)), Quaternion.identity);
        droppedItem.AddComponent<Rigidbody>().useGravity = true;
        droppedItem.name = draggedItem.NAME;

        droppedItem = null;
    }
    #endregion
    #region Draw Item
    // Show icon when dragging
    private void DrawItem(int windowID)
    {
        if (draggedItem.ICON != null)
        {
            GUI.DrawTexture(new Rect(0, 0, scr.x * 0.5f, scr.y * 0.5f), draggedItem.ICON);
        }
    }
    #endregion
    #region ToolTip

    #region ToolTip Content
    private string ToolTipText(int index)
    {
        // Takes the name, description and value and shows it on the window
        string toolTipText = inv[index].NAME + "\n" + inv[index].DESCRIPTION + "\nValue: " + inv[index].VALUE;

        return toolTipText;
    }
    #endregion
    #region ToolTip Window
    // Basic window for the ToolTip
    private void DrawToolTip(int windowID)
    {
        GUI.Box(new Rect(0, 0, scr.x * 6, scr.y * 2), ToolTipText(toolTipItem));
    }
    #endregion

    #endregion
    #region Toggle Inventory
    private void ToggleInv()
    {
        // Basic Toggle: Pause, Shows Mouse, else the opposite
        showInv = !showInv;
        if (showInv)
        {
            Movement.canMove = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Movement.canMove = true;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    #endregion
    #region Inventory Drag
    private void InventoryDrag(int windowID)
    {
        // Banner and Gold Display window
        GUI.Box(new Rect(0, scr.y * 0.25f, scr.x * 5.5f, scr.y * 0.25f), "Banner");
        GUI.Box(new Rect(0, scr.y * 4.25f, scr.x * 5.5f, scr.y * 0.24f), "Kevin");
        showToolTip = false;

        #region Nested for Loop
        int i = 0;
        Event e = Event.current;
        for (int y = 0; y < slotY; y++)
        {
            for (int x = 0; x < slotX; x++)
            {
                // Slots of the Inventory (the boxes)
                Rect slotLocation = new Rect(
                                            scr.x * 0.125f + x * (scr.x * 0.75f),
                                            scr.y * 0.75f + y * (scr.y * 0.65f),
                                            scr.x * 0.75f,
                                            scr.y * 0.65f
                                            );
                GUI.Box(slotLocation, "");

                #region Pickup Item
                // ... You are picking an Item
                if (e.button == 0 && e.type == EventType.MouseDown && slotLocation.Contains(e.mousePosition) && !isDragging && inv[i].NAME != null && !Input.GetKey(KeyCode.LeftShift))
                {
                    draggedItem = inv[i];
                    inv[i] = new Item();
                    isDragging = true;
                    draggedFrom = i;
                    Debug.Log("Currently draging your " + draggedItem.NAME);
                }
                #endregion
                #region Swap Item
                // ... You are swaping an Item
                if (e.button == 0 && e.type == EventType.MouseUp && slotLocation.Contains(e.mousePosition) && isDragging && inv[i].NAME != null)
                {
                    Debug.Log("Swapped your " + draggedItem.NAME + " with " + inv[i].NAME);
                    inv[draggedFrom] = inv[i];
                    inv[i] = draggedItem;
                    draggedItem = new Item();
                    isDragging = false;
                }
                #endregion
                #region Place Item
                // ... You are placing an Item
                if (e.button == 0 && e.type == EventType.MouseUp && slotLocation.Contains(e.mousePosition) && isDragging && inv[i].NAME == null)
                {
                    Debug.Log("Placing your " + draggedItem.NAME);
                    inv[i] = draggedItem;
                    draggedItem = new Item();
                    isDragging = false;
                }
                #endregion

                #region Return Item
                // Empty for now
                #endregion
                #region Draw Item
                if (inv[i].NAME != null)
                {
                    // Set the icon to draw
                    GUI.DrawTexture(slotLocation, inv[i].ICON);

                    #region Set ToolTip on Mouse Hover
                    // Show ToolTip with Mouse Hover
                    if (slotLocation.Contains(e.mousePosition) && !isDragging && showInv)
                    {
                        toolTipItem = i;
                        showToolTip = true;
                    }
                    #endregion
                }
                #endregion

                i++;
            }
        }
        #endregion
        #region Drag Points
        // Where can you click to drag the window
        GUI.DragWindow(new Rect(0, 0, scr.x * 6, scr.y * 0.25f)); //Top
        GUI.DragWindow(new Rect(0, scr.y * 0.25f, scr.x * 0.25f, scr.y * 3.75f)); //Left
        GUI.DragWindow(new Rect(scr.x * 5.5f, scr.y * 0.25f, scr.x * 0.25f, scr.y * 3.75f)); //Right
        GUI.DragWindow(new Rect(0, scr.y * 4, scr.x * 6, scr.y * 0.25f)); //Button
        #endregion
    }
    #endregion

    #region Start
    private void Start()
    {
        // Make the screen scalable
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
        inventorySize = new Rect(scr.x, scr.y, scr.x * 5.5f, scr.y * 4.5f);
        for (int i = 0; i < (slotX * slotY); i++)
        {
            inv.Add(new Item());
        }
        // For Testing
        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(100);
        AddItem(101);
        AddItem(102);
        AddItem(200);
        AddItem(201);
        AddItem(202);
        AddItem(300);
        AddItem(301);
        AddItem(302);
        AddItem(400);
        AddItem(401);
        AddItem(402);
        AddItem(500);
        AddItem(501);
        AddItem(502);
    }
    #endregion
    #region Update
    private void Update()
    {
        if (Input.GetKeyDown(DragNDropOpen))
        {
            ToggleInv();
        }
        // Check if the window is not correctly sized, and fix it
        if (scr.x != Screen.width / 16)
        {
            scr.x = Screen.width / 16;
            scr.x = Screen.height / 9;
            inventorySize = new Rect(scr.x, scr.y, scr.x * 6, scr.y * 4.5f);
        }
    }
    #endregion
    #region OnGUI
    private void OnGUI()
    {
        Event e = Event.current;

        #region Inventory when True
        // Show Inventory
        if (showInv)
        {
            inventorySize = ClampToScreen(GUI.Window(1, inventorySize, InventoryDrag, "Player Inventory"));

            #region ToolTipDisplay
            // Show ToolTip
            if (showToolTip)
            {
                toolTipRect = new Rect(e.mousePosition.x + 0.01f, e.mousePosition.y + 0.01f, scr.x * 6, scr.y * 2);
                GUI.Window(7, toolTipRect, DrawToolTip, "");
            }
            #endregion
        }
        #endregion
        #region Drop Item
        // Drop the item when dragging it out
        if ((e.button == 0 && e.type == EventType.MouseUp && isDragging) || (isDragging && !showInv))
        {
            DropItem();
            Debug.Log("Dropped Item" + draggedItem.NAME);
            draggedItem = new Item();
            isDragging = false;
        }
        #endregion
        #region Draw Item On Mouse
        // Draw the icon when moving the mouse
        if (isDragging)
        {
            if (draggedItem != null)
            {
                Rect mouseLocation = new Rect(e.mousePosition.x + 0.125f, e.mousePosition.y + 0.125f, scr.x * 0.5f, scr.y * 0.5f);
                GUI.Window(72, mouseLocation, DrawItem, "");
            }
        }
        #endregion
        #endregion
    }
}