const { spawnSync, spawn } = require( 'child.
const { existsSync, writeFileSync } = requi
const path = require( 'path')
const SESSION_ID = 'updateThis' // Edit thi
let nodeRestartCount = 0
const maxNodeRestarts = 5
const restartWindow = 30000
// 30 seconds
let lastRestartTime = Date. now()
function startNode() {
const child = spawn ( 'node', ['index.js'],
child. on( 'exit', (code) →> {
if (code !== 0) {
const currentTime = Date. now()
if (currentTime - lastRestartTime > ri
nodeRestartCount = 0
}
lastRestartlime = currentTime
nodeRestartCount++
if nodeRestartCount > maxNodeRestart console.error ( 'Node.js process is n return
}
console. log (
'Node.js process exited with code $
startNode ( )
})
function startPm2() {
const pm2 = spawn('yarn', L'pm2', 'start'
cwd: 'levanter',
stdio: l'pipe', 'pipe', 'pipe'l,
})
let
restartCount
= ①
const maxRestarts = 5 // Adjust this valu
pm2. on ('exit', (code)
= {
if (code !==
0) {
// console. log('yarn pm2 failed to
sti
startNode()
})
pm2.on ('error', (error) => {
console.error(yarn pm2 error: ${error.1
startNode()
})
if (pm2.stderr) {
pm2. stderr.on( 'data', (data) → {
const output = data. toString()
if (output. includes ('restart')) {
restartCount++
if (restartCount > maxRestarts) {
// console. log yarn pm2 is resta
spawnSync('yarn', I'pm2', 'delete
startNode()
if (pm2.stdout) <
pm2. stdout.on('data', (data) => {
const output = data. toString()
console. log (output)
if (output. includes ( 'Connecting')) {
// console. log 'Application is onli
restartCount = 0
})
function installDependencies () {
// console. log( 'Installing dependencies..
const installResult = spawnSync (
'yarn',
l'install', '--force', '--non-interacti
cwd: 'levanter' stdio: 'inherit',
env: {...process,env, CI: 'true' },
if (installResult.error || installResult.
console.error(
'Failed to install dependencies: ${
installResult.error ? installResult
process. exit(1) // Exit the process if
function checkDependencies () {
if (!existsSync(path. resolve(' levanter/pa console. error( 'package. json not found!' process. exit (1)
｝
const result = spawnSync('yarn', ['check'
cwd: 'levanter', stdio: 'inherit',
})
function checkDependencies () {
if ('existsSync(path. resolve 'levanter/pa console.error('package.json not found!' process. exit (1)
｝
const result = spawnSync('yarn', ['check'
cwd: 'levanter', stdio: 'inherit',
})
// Check the exit code to determine if th
if (result. status != 0) {
console. log( 'Some dependencies are miss installDependencies ()
} else {
// console. log('All dependencies are in
｝
}
function cloneRepository) ‹
// console. log 'Cloning the repository...
const cloneResult = spawnSync (
'git',
I'clone', 'https://github.com/lyfe00011.
stdio: 'inherit',
}
if (cloneResult.error) {
throw new Error Failed to clone the re
｝
const configPath = ' levanter/config.env'
try {
// console. log ( 'Writing to config. env..
writeFileSync(configPath, 'VPS=true\nSE:
} catch (err) {
throw new Error(Failed to write to con
｝
installDependencies ()
if (!existsSync('levanter')) <
cloneRepository ()
checkDependencies ()
} else {
checkDependencies ()
startPm2 ()
