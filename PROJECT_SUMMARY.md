# File Management Tool - Project Summary

## Project Overview
**FileManagementTool** is a Windows Forms desktop application built with C# (.NET Framework 4.7.2) that automatically organizes files from a source folder into categorized destination folders based on file extensions. The application provides a user-friendly GUI for file organization with configurable categories, comprehensive logging, and error handling.

## Technology Stack
- **Framework**: .NET Framework 4.7.2
- **UI Framework**: Windows Forms
- **Language**: C#
- **JSON Library**: Newtonsoft.Json 13.0.4
- **Architecture**: Layered architecture with separation of concerns

## Project Structure

### Core Components

#### 1. **File Management Module** (`FileManagment/`)
- **FileScanner.cs**: Scans source directory for files, extracts metadata (name, extension, size, last modified date), and filters out hidden/system files. Returns a list of `ScannedFile` objects.
- **FileOrganizer.cs**: Handles the actual file organization process:
  - Creates category folders in destination
  - Copies files to appropriate category folders
  - Handles duplicate file names by appending numbers
  - Provides progress events for UI updates
  - Returns detailed operation results (success/failure counts)
- **CategoryManager.cs**: Manages file categorization:
  - Maps file extensions to categories
  - Groups files by category
  - Provides folder name mapping for categories
  - Handles "Unknown" category for unmapped extensions

#### 2. **Configuration Module** (`Configuration/`)
- **ConfigurationManager.cs**: Manages application configuration:
  - Loads/saves configuration from JSON file (stored in `%LocalAppData%\FileManagementTool\categories.json`)
  - Provides default categories (Documents, Images, Videos, Audio, Archives, Executables)
  - Validates configuration data
  - Supports switching between default and custom configurations
- **ConfigValidator.cs**: Validates configuration data:
  - Validates category names, folder names, and extensions
  - Checks for duplicates and invalid characters
  - Returns detailed validation results

#### 3. **Folder Management Module** (`FolderManagment/`)
- **FolderManager.cs**: Utility class for folder operations:
  - Creates timestamped folders
  - Validates folder writability
  - Calculates folder sizes
  - Provides access to common system folders (Desktop, Documents, Downloads)

#### 4. **Error Handling Module** (`ErrorHandling/`)
- **ErrorLogger.cs**: Singleton logging system:
  - Logs errors, warnings, and informational messages
  - Writes to timestamped log files in `%LocalAppData%\FileManagementTool\Logs\`
  - Provides log summaries and full log retrieval
  - Supports different log levels (Info, Warning, Error)
  - Tracks file operations and general operations

#### 5. **Models** (`Models/`)
- **Category.cs**: Data model representing a file category:
  - Name (display name)
  - FolderName (destination folder name)
  - Extensions (list of file extensions for this category)

#### 6. **User Interface** (`UI/`)
- **MainForm.cs**: Main application window with:
  - Source folder selection (browse button)
  - Optional destination folder selection (defaults to timestamped folder on Desktop)
  - Configuration toggle (default vs custom)
  - Configuration editor button
  - Configuration reset button
  - Start/Cancel buttons
  - Progress bar and status label
  - Link to view logs
  - Real-time progress updates during file organization
  - Validation of user inputs
  - Result summary with option to open destination folder

- **ConfigEditorForm.cs**: Configuration editor dialog:
  - List of categories with add/remove functionality
  - Category editor (name, folder name)
  - Extension management (add/remove extensions with visual chips)
  - Save/Reset/Close buttons
  - Unsaved changes detection
  - Real-time validation feedback
  - Minimum one category requirement

- **LogViewerForm.cs**: Log viewing dialog:
  - Displays full log content in read-only text box
  - Copy to clipboard functionality
  - Save log to file functionality
  - Keyboard shortcuts (Ctrl+A for select all)

## Default Configuration
The application comes with 6 default categories:
1. **Documents**: `.txt`, `.doc`, `.docx`, `.pdf`, `.xlsx`, `.pptx`, `.rtf`
2. **Images**: `.jpg`, `.jpeg`, `.png`, `.gif`, `.bmp`, `.tiff`, `.svg`
3. **Videos**: `.mp4`, `.avi`, `.mov`, `.wmv`, `.mkv`, `.flv`
4. **Audio**: `.mp3`, `.wav`, `.aac`, `.flac`, `.m4a`, `.ogg`
5. **Archives**: `.zip`, `.rar`, `.7z`, `.tar`, `.gz`
6. **Executables**: `.exe`, `.msi`, `.bat`, `.cmd`

## Key Features Implemented

### 1. **File Organization Workflow**
- User selects source folder containing files to organize
- Optional destination folder (or auto-creates timestamped folder on Desktop)
- Files are scanned from source folder (non-recursive, top-level only)
- Files are categorized based on extension mapping
- Category folders are created in destination
- Files are copied (not moved) to appropriate category folders
- Duplicate file names are handled with numbered suffixes
- Progress is tracked and displayed in real-time

### 2. **Configuration Management**
- Default configuration built into application
- Custom configuration stored in JSON format
- Configuration editor with full CRUD operations for categories
- Extension management with visual chips
- Configuration validation before saving
- Reset to defaults functionality

### 3. **Error Handling & Logging**
- Comprehensive error logging to file
- Error tracking for file operations
- Log viewer with export capabilities
- Graceful error handling (continues processing other files if one fails)
- User-friendly error messages

### 4. **User Experience**
- Clean, intuitive Windows Forms interface
- Real-time progress updates
- Status messages and feedback
- Input validation with helpful error messages
- Option to open destination folder after completion
- Visual indicators for configuration status

## Data Storage
- **Configuration**: `%LocalAppData%\FileManagementTool\categories.json`
- **Logs**: `%LocalAppData%\FileManagementTool\Logs\log_YYYYMMDD_HHMMSS.txt`

## Current Limitations / Known Issues
1. **File Scanning**: Only scans top-level directory (non-recursive)
2. **File Operations**: Files are copied, not moved (original files remain in source)
3. **Cancellation**: Cancel button exists but cancellation logic is not fully implemented (marked as TODO)
4. **Configuration Reset**: Reset functionality in MainForm has TODO comment for actual implementation
5. **Threading**: File operations are synchronous (may cause UI freezing for large operations)

## Dependencies
- **Newtonsoft.Json** (13.0.4): JSON serialization/deserialization
- **System.Text.Json** (10.0.1): Additional JSON support
- Various System.* packages for async and memory operations

## Build Configuration
- **Target Framework**: .NET Framework 4.7.2
- **Output Type**: Windows Application (WinExe)
- **Platform**: AnyCPU
- **Build Configurations**: Debug and Release

## Application Flow
1. Application starts → MainForm loads
2. User selects source folder (required)
3. User optionally selects destination folder
4. User chooses default or custom configuration
5. User clicks "Start" → Validation occurs
6. Configuration is loaded
7. Files are scanned from source folder
8. Files are categorized by extension
9. Category folders are created in destination
10. Files are copied to appropriate folders
11. Progress is updated throughout
12. Results are displayed with summary
13. User can view logs or open destination folder

## Code Quality Features
- Separation of concerns (UI, Business Logic, Data Access)
- Singleton pattern for ErrorLogger
- Event-driven architecture for progress updates
- Comprehensive error handling with try-catch blocks
- Input validation at multiple levels
- Configuration validation before saving
- Logging for debugging and audit trails

## Future Enhancement Opportunities
1. Recursive folder scanning option
2. Move files instead of copy option
3. Async/await for non-blocking UI operations
4. Cancellation token support for long operations
5. Preview mode before actual organization
6. Undo functionality
7. File filtering (by size, date, etc.)
8. Custom rules beyond extension-based categorization
9. Batch processing multiple source folders
10. Export/import configuration profiles

