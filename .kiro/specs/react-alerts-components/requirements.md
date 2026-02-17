# Requirements Document

## Introduction

This document specifies the requirements for implementing React Alerts components based on the existing Razor/Blazor implementation. The system SHALL provide a comprehensive set of alert and notification components including Badge, Notification, Feedback, and a programmatic notification system with context-based state management. These components enable developers to display inline badges, dismissible notifications with timers, structured feedback messages, and programmatically triggered notifications positioned at various screen locations.

## Glossary

- **Badge**: An inline component that displays text or content with optional icons, used for labels, status indicators, or tags
- **Notification**: A dismissible alert component with optional auto-close timer, progress bar, and icon, typically used for temporary messages
- **Feedback**: A structured message component with title, text, icon, and optional close button, used for persistent alerts or informational messages
- **NotificationContent**: A helper component that structures notification content with main text and additional details
- **NotificationOutlet**: A component that renders all active notifications grouped by screen placement
- **NotificationProvider**: A React Context provider that manages notification state
- **Notify_Service**: A service accessed via useNotify() hook that provides methods for programmatically showing notifications
- **Theme**: A visual style variant (Primary, Secondary, Tertiary, Success, Danger, Warning, Alert, Info, Highlight, Light, Dark)
- **Size**: A size variant (Smallest, Smaller, Small, Medium, Large, Larger, Largest)
- **Placement**: Screen position for notifications (TopStart, TopCenter, TopEnd, BottomStart, BottomCenter, BottomEnd)
- **IconPosition**: Position of icon relative to content (Start or End)
- **Timer**: Auto-close duration in milliseconds
- **NotificationHandle**: A ref interface exposing programmatic control methods (open, close)

## Requirements

### Requirement 1: Badge Component

**User Story:** As a developer, I want to render inline badges with text, icons, themes, and sizes, so that I can display labels, status indicators, and tags throughout the application.

#### Acceptance Criteria

1. WHEN a Badge is rendered with text content, THE Badge SHALL display the text inside a div element with class "ya-badge"
2. WHEN a Badge is rendered with children content, THE Badge SHALL display the children inside a div element with class "ya-badge"
3. WHEN a Badge is rendered with a theme prop, THE Badge SHALL apply the class "ya-badge-{theme}" where theme is one of: primary, secondary, tertiary, success, danger, warning, alert, info, highlight, light, dark
4. WHEN a Badge is rendered with a size prop, THE Badge SHALL apply the class "ya-badge-{size}" where size is one of: smallest, smaller, small, medium, large, larger, largest
5. WHEN a Badge is rendered with an icon and iconPosition="start", THE Badge SHALL render the icon before the content
6. WHEN a Badge is rendered with an icon and iconPosition="end", THE Badge SHALL render the icon after the content
7. WHEN a Badge is rendered without a theme prop, THE Badge SHALL apply the default theme "primary"
8. WHEN a Badge is rendered without a size prop, THE Badge SHALL apply the default size "medium"
9. WHEN a Badge is rendered with iconPosition="center", THE Badge SHALL throw a validation error indicating center position is not supported

### Requirement 2: Notification Component Structure

**User Story:** As a developer, I want to render notification components with structured layout including icon, content, and close button sections, so that I can display consistent alert messages.

#### Acceptance Criteria

1. WHEN a Notification is rendered, THE Notification SHALL render a div element with role="alert" and class "ya-notification"
2. WHEN a Notification is rendered with a theme prop, THE Notification SHALL apply the class "ya-notification-{theme}"
3. WHEN a Notification is rendered, THE Notification SHALL contain a container div with class "ya-notification-box"
4. WHEN a Notification is rendered with icon=true, THE Notification SHALL render an icon section with class "ya-notification-icon" containing a theme-appropriate icon
5. WHEN a Notification is rendered with icon=false, THE Notification SHALL render a colored bar div with class "ya-notification-bar"
6. WHEN a Notification is rendered, THE Notification SHALL render a content section with class "ya-notification-content" containing the text or children
7. WHEN a Notification is rendered with closeable=true, THE Notification SHALL render a close button section with class "ya-notification-close"
8. WHEN a Notification is rendered without a theme prop, THE Notification SHALL apply the default theme "info"

### Requirement 3: Notification Timer and Auto-Close

**User Story:** As a developer, I want notifications to auto-close after a specified duration with a visual progress bar, so that temporary messages disappear automatically without user interaction.

#### Acceptance Criteria

1. WHEN a Notification is rendered with a timer prop (milliseconds), THE Notification SHALL automatically close after the specified duration
2. WHEN a Notification has an active timer, THE Notification SHALL render a progress bar div with class "ya-notification-timer"
3. WHEN a Notification timer is active, THE progress bar SHALL animate from full width to zero width over the timer duration
4. WHEN a user hovers over a Notification with an active timer, THE timer SHALL pause and the progress bar animation SHALL pause
5. WHEN a user moves the mouse out of a Notification with a paused timer, THE timer SHALL resume and the progress bar animation SHALL resume
6. WHEN a Notification timer completes, THE Notification SHALL call the onClose callback if provided
7. WHEN a Notification timer completes, THE Notification SHALL set its closed state to true

### Requirement 4: Notification Interaction and Control

**User Story:** As a developer, I want to control notification visibility through user interactions and programmatic methods, so that I can respond to user actions and manage notification state.

#### Acceptance Criteria

1. WHEN a Notification is rendered with closeOnClick=true and the user clicks the notification, THE Notification SHALL close
2. WHEN a Notification is rendered with closeable=true and the user clicks the close button, THE Notification SHALL close
3. WHEN a Notification closes, THE Notification SHALL call the onClose callback if provided
4. WHEN a Notification opens, THE Notification SHALL call the onOpen callback if provided
5. WHEN a Notification is rendered with startClosed=true, THE Notification SHALL initially be in closed state
6. WHEN a NotificationHandle ref is attached to a Notification, THE ref SHALL expose a close() method that closes the notification
7. WHEN a NotificationHandle ref is attached to a Notification, THE ref SHALL expose an open() method that opens the notification
8. WHEN a Notification is controlled via the open prop, THE Notification SHALL use the open prop value to determine visibility
9. WHEN a Notification is uncontrolled, THE Notification SHALL manage its own open state internally

### Requirement 5: NotificationContent Component

**User Story:** As a developer, I want to structure notification content with main text and additional details, so that I can display hierarchical information in notifications.

#### Acceptance Criteria

1. WHEN a NotificationContent is rendered, THE NotificationContent SHALL render a div with class "ya-notification-content-group"
2. WHEN a NotificationContent is rendered with a text prop, THE NotificationContent SHALL render the text in a div with class "ya-notification-content-text"
3. WHEN a NotificationContent is rendered with a details prop, THE NotificationContent SHALL render the details in a div with class "ya-notification-content-details"
4. WHEN a NotificationContent is rendered with both text and details, THE text SHALL appear before the details

### Requirement 6: Feedback Component

**User Story:** As a developer, I want to render structured feedback messages with title, text, icon, and optional close button, so that I can display persistent alerts and informational messages.

#### Acceptance Criteria

1. WHEN a Feedback is rendered, THE Feedback SHALL render a div element with class "ya-feedback"
2. WHEN a Feedback is rendered with a theme prop, THE Feedback SHALL apply the class "ya-feedback-{theme}"
3. WHEN a Feedback is rendered with a size prop, THE Feedback SHALL apply the class "ya-feedback-{size}"
4. WHEN a Feedback is rendered with block=true, THE Feedback SHALL apply the class "ya-feedback-block"
5. WHEN a Feedback is rendered with an icon prop, THE Feedback SHALL render an icon section with class "ya-feedback-icon"
6. WHEN a Feedback is rendered, THE Feedback SHALL render a content section with class "ya-feedback-content"
7. WHEN a Feedback is rendered with a title prop, THE Feedback SHALL render the title in a heading element with class "ya-feedback-title"
8. WHEN a Feedback is rendered with a title and size="smallest", THE title SHALL be rendered as an h6 element
9. WHEN a Feedback is rendered with a title and size="smaller", THE title SHALL be rendered as an h5 element
10. WHEN a Feedback is rendered with a title and size="small", THE title SHALL be rendered as an h4 element
11. WHEN a Feedback is rendered with a title and size="medium", THE title SHALL be rendered as an h3 element
12. WHEN a Feedback is rendered with a title and size="large", THE title SHALL be rendered as an h3 element
13. WHEN a Feedback is rendered with a title and size="larger", THE title SHALL be rendered as an h2 element
14. WHEN a Feedback is rendered with a title and size="largest", THE title SHALL be rendered as an h2 element
15. WHEN a Feedback is rendered with a text prop, THE Feedback SHALL render the text in a paragraph with class "ya-feedback-text"
16. WHEN a Feedback is rendered with children, THE Feedback SHALL render the children after the title and text
17. WHEN a Feedback is rendered with closeable=true, THE Feedback SHALL render a close button
18. WHEN a user clicks the close button on a Feedback, THE Feedback SHALL close and call the onClose callback if provided
19. WHEN a Feedback is rendered without a theme prop, THE Feedback SHALL apply the default theme "info"
20. WHEN a Feedback is rendered without a size prop, THE Feedback SHALL apply the default size "medium"
21. WHEN a Feedback is rendered without a block prop, THE Feedback SHALL apply block=true by default

### Requirement 7: Notification System Context and Provider

**User Story:** As a developer, I want to manage notification state through React Context, so that I can programmatically show and dismiss notifications from any component in the application.

#### Acceptance Criteria

1. WHEN a NotificationProvider is rendered, THE NotificationProvider SHALL create a React Context for notification state
2. WHEN a NotificationProvider is rendered, THE NotificationProvider SHALL initialize an empty notification collection
3. WHEN a notification is added to the NotificationProvider, THE NotificationProvider SHALL store the notification with a unique ID
4. WHEN a notification is removed from the NotificationProvider, THE NotificationProvider SHALL remove the notification by ID
5. WHEN a NotificationProvider manages notifications, THE NotificationProvider SHALL group notifications by placement (TopStart, TopCenter, TopEnd, BottomStart, BottomCenter, BottomEnd)
6. WHEN the notification state changes, THE NotificationProvider SHALL trigger re-renders of consuming components

### Requirement 8: useNotify Hook and Programmatic API

**User Story:** As a developer, I want to programmatically show notifications using a hook-based API, so that I can trigger notifications in response to application events.

#### Acceptance Criteria

1. WHEN useNotify() is called within a NotificationProvider, THE hook SHALL return a notify service object
2. WHEN useNotify() is called outside a NotificationProvider, THE hook SHALL throw an error
3. WHEN notify.show() is called with a notification configuration, THE Notify_Service SHALL add the notification to the provider state
4. WHEN notify.show() is called with theme, text, and details parameters, THE Notify_Service SHALL create and show a notification with those properties
5. WHEN notify.primary() is called with text and details, THE Notify_Service SHALL show a notification with theme="primary"
6. WHEN notify.secondary() is called with text and details, THE Notify_Service SHALL show a notification with theme="secondary"
7. WHEN notify.tertiary() is called with text and details, THE Notify_Service SHALL show a notification with theme="tertiary"
8. WHEN notify.success() is called with text and details, THE Notify_Service SHALL show a notification with theme="success"
9. WHEN notify.danger() is called with text and details, THE Notify_Service SHALL show a notification with theme="danger"
10. WHEN notify.warning() is called with text and details, THE Notify_Service SHALL show a notification with theme="warning"
11. WHEN notify.alert() is called with text and details, THE Notify_Service SHALL show a notification with theme="alert"
12. WHEN notify.info() is called with text and details, THE Notify_Service SHALL show a notification with theme="info"
13. WHEN notify.highlight() is called with text and details, THE Notify_Service SHALL show a notification with theme="highlight"
14. WHEN notify.light() is called with text and details, THE Notify_Service SHALL show a notification with theme="light"
15. WHEN notify.dark() is called with text and details, THE Notify_Service SHALL show a notification with theme="dark"
16. WHEN notify.show() is called without a timer value, THE Notify_Service SHALL calculate a timer duration based on text length
17. WHEN calculating auto timer duration, THE Notify_Service SHALL use a minimum duration of 3000ms and add 50ms per character in the text

### Requirement 9: NotificationOutlet Component

**User Story:** As a developer, I want to render all active notifications grouped by screen placement, so that notifications appear in the correct positions and stack properly.

#### Acceptance Criteria

1. WHEN a NotificationOutlet is rendered, THE NotificationOutlet SHALL consume the notification context from NotificationProvider
2. WHEN a NotificationOutlet is rendered, THE NotificationOutlet SHALL render notification groups for each placement position
3. WHEN a NotificationOutlet renders a notification group, THE group SHALL have class "ya-notification-group" and "ya-notification-group-{placement}"
4. WHEN notifications exist for a placement, THE NotificationOutlet SHALL render each notification in that placement group
5. WHEN a notification in the outlet is closed, THE NotificationOutlet SHALL remove the notification from the provider state
6. WHEN the notification state updates, THE NotificationOutlet SHALL automatically re-render to reflect changes

### Requirement 10: TypeScript Type Definitions

**User Story:** As a developer using TypeScript, I want comprehensive type definitions for all components and APIs, so that I get type safety and IDE autocomplete.

#### Acceptance Criteria

1. THE Badge component SHALL export a BadgeProps interface defining all prop types
2. THE Notification component SHALL export a NotificationProps interface defining all prop types
3. THE NotificationContent component SHALL export a NotificationContentProps interface defining all prop types
4. THE Feedback component SHALL export a FeedbackProps interface defining all prop types
5. THE NotificationHandle interface SHALL define close() and open() method signatures
6. THE Theme type SHALL be a union of all valid theme values
7. THE Size type SHALL be a union of all valid size values
8. THE Placement type SHALL be a union of all valid placement values
9. THE IconPosition type SHALL be a union of "start" and "end"
10. THE NotificationItem interface SHALL define the structure for programmatic notification configuration
11. THE useNotify hook SHALL return a typed NotifyService interface

### Requirement 11: Accessibility

**User Story:** As a user relying on assistive technologies, I want alert components to be properly announced and navigable, so that I can perceive and interact with notifications.

#### Acceptance Criteria

1. WHEN a Notification is rendered, THE Notification SHALL have role="alert" attribute
2. WHEN a Feedback is rendered, THE Feedback SHALL have role="alert" attribute
3. WHEN a close button is rendered, THE close button SHALL have an accessible label
4. WHEN a Notification has a timer, THE timer progress bar SHALL have appropriate ARIA attributes
5. WHEN a Badge contains only an icon, THE icon SHALL have an accessible label

### Requirement 12: CSS Class Application

**User Story:** As a developer, I want components to apply consistent CSS classes matching the Razor implementation, so that existing stylesheets work without modification.

#### Acceptance Criteria

1. THE Badge component SHALL apply CSS classes: ya-badge, ya-badge-{theme}, ya-badge-{size}
2. THE Notification component SHALL apply CSS classes: ya-notification, ya-notification-{theme}, ya-notification-box, ya-notification-icon, ya-notification-bar, ya-notification-content, ya-notification-close, ya-notification-timer
3. THE NotificationContent component SHALL apply CSS classes: ya-notification-content-group, ya-notification-content-text, ya-notification-content-details
4. THE Feedback component SHALL apply CSS classes: ya-feedback, ya-feedback-{theme}, ya-feedback-{size}, ya-feedback-block, ya-feedback-icon, ya-feedback-content, ya-feedback-title, ya-feedback-text
5. THE NotificationOutlet component SHALL apply CSS classes: ya-notification-group, ya-notification-group-{placement}
