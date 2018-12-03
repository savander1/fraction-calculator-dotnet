// Modules to control application life and create native browser window
const {app, BrowserWindow, Menu} = require('electron')

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mainWindow

function createWindow () {
  // Create the browser window.
  mainWindow = new BrowserWindow({
    width: 422, 
    height: 560, 
    minHeight: 460,
    thickFrame: true, 
    resizable: true,
    icon: 'calculator-icon.ico'
  })

  // and load the index.html of the app.
  mainWindow.loadFile('index.html')

  // mainWindow.setMenu(Menu.buildFromTemplate([
  //   { id: '1', label: 'one' },
  //   { type: 'separator' },
  //   { id: '3', label: 'three', beforeGroupContaining: ['1'] },
  //   { id: '4', label: 'four', afterGroupContaining: ['2'] },
  //   { type: 'separator' },
  //   { id: '2', label: 'two' }
  // ]))

  // Open the DevTools.
  //ainWindow.webContents.openDevTools()
  

  // Emitted when the window is closed.
  mainWindow.on('closed', function () {
    // Dereference the window object, usually you would store windows
    // in an array if your app supports multi windows, this is the time
    // when you should delete the corresponding element.
    mainWindow = null
  })
}

app.setName('Fraction Caclulator');

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', createWindow)

// Quit when all windows are closed.
app.on('window-all-closed', function () {
  // On macOS it is common for applications and their menu bar
  // to stay active until the user quits explicitly with Cmd + Q
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', function () {
  // On macOS it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (mainWindow === null) {
    createWindow()
  }
})

// In this file you can include the rest of your app's specific main process
// code. You can also put them in separate files and require them here.
