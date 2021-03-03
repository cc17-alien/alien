Alien!
======

Game flow
---------

Below is an illustration of gameplay from creation to game over.

<img src="./img/gameflow.jpg" />

Contribution guidelines
-----------------------

### Git

#### Feature branches

Any changes must be made on feature branches. `main` is protected and cannot be changed directly.

To merge changes into `main`, open a pull request from a feature branch. At least one review is required before merging.

#### Commit standards

- Include a summary: a short, concise statement summarising your commit. Does not end in a period.
- Include a body: expands on the summary, giving full details on what changed. This can be multiple lines or a bulleted list. Uses correct punctuation and grammar. Not necessary if the summary sufficiently describes the changes.
- Include a footer: references specific issue on Github. Can reference multiple issues. Use verbs "resolves", "fixes", "closes", followed by issue number. Not necessary if the commit does not pertain to an issue hosted on Github.
- A commit consists of changes related to *one* thing. If your code pertains to several things, break it up into multiple commits.
- Use "WIP" for works in progress.

#### Summary/body/footer structure

- Summary: max 50 characters
- Body: max 72 characters
- Footer: max 72 characters (although you only need ~10)

This is an illustration of character limits:

```
|~summary~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|

|~body~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|

|~footer~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|
```

Here is an example commit:

```
Increase noise from objective completion

Noise generation doubled. Previous noise level was not resulting in a
noticable change in alien behaviour towards player.

resolving #22
```
